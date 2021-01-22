 private delegate void NodeHandler(ChildNode node);
 static Dictionary&lt;RuntimeTypeHandle, NodeHandler&gt; TypeHandleSwitcher =
      CreateSwitcher();
 private static Dictionary&lt;RuntimeTypeHandle, NodeHandler&gt; CreateSwitcher() {
  Dictionary&lt;RuntimeTypeHandle, NodeHandler&gt; ret = 
    new Dictionary&lt;RuntimeTypeHandle, NodeHandler&gt;();
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
