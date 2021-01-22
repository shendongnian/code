A static field is defined in a "hidden" location that is associated with the class containing the switch statement of type Dictionary<string, int> and given a mangled name 
//Make sure the dictionary is loaded
if(theDictionary == null) { 
 //This is simplified for clarity, the actual implementation is more complex 
 // in order to ensure thread safety
 theDictionary = new Dictionary<string,int>();
 theDictionary["Foo"] = 0;
 theDictionary["Bar"] = 1;
}
int switchIndex;
if(theDictionary.TryGetValue(someString, out switchIndex)) {
 switch(switchIndex) {
  case 0: DoFoo(); break;
  case 1: DoBar(); break;
 }
}
else {
 DoOther();
}
In some quick tests that I just ran, the If/Else method is about 3x as fast as the switch for 3 different types (where the types are randomly distributed).  At 25 types the switch is faster by a small margin (16%) at 50 types the switch is more than twice as fast.
If you are going to be switching on a large number of types, I would suggest a 3rd method:
 private delegate void NodeHandler(ChildNode node);
 private static Dictionary<RuntimeTypeHandle, NodeHandler> TypeHandleSwitcher = CreateSwitcher();
 private static Dictionary<RuntimeTypeHandle, NodeHandler> CreateSwitcher() {
  Dictionary<RuntimeTypeHandle, NodeHandler> ret = new Dictionary<RuntimeTypeHandle, NodeHandler>();
  ret[typeof(Bob).TypeHandle] = HandleBob;
  ret[typeof(Jill).TypeHandle] = HandleJill;
  ret[typeof(Marko).TypeHandle] = HandleMarko;
  return ret;
 }
 void HandleChildNode(ChildNode node) {
  NodeHandler handler;
  if(TaskHandleSwitcher.TryGetValue(Type.GetRuntimeType(node), out handler)) {
   handler(node);
  }
  else {
   //Unexpected type...
  }
 }
}
