    public class Calculator
    {
        [MyAttribute1(MyAttributeValue="Hello World")]
        public int Add(int a, int b)
        {
            return a + b;
        }
    }
    public class MyAspect : IAspect
    {
        //This code will be executed to create a decorator, not in nominal execution flow (You don't have to stress with performance here)
        public IEnumerable<IAdvice> Advise(MethodInfo method)
        {
            var myattribute1 = method.GetCustomAttributes(typeof(MyAttribute1), true).Cast<MyAttribute1>().SingleOrDefault();
            
            //If attribute is not defined, do not return an "advice"
            if (myattribute1 == null) { yield break; }
            //Get your attribute property.
            var myattributevalue = myattribute1.MyAttributeValue;
            
            //define your substitute method
            var signature= new Type[] { method.DeclaringType }.Concat(method.GetParameters().Select(parameter => parameter.Type)).ToArray();
            var dynamicMethod = new DynamicMethod(string.Empty, method.ReturnType, signature, method.DeclaringType, true);
            var body = dynamicMethod.GetILGenerator();
            //TODO : emit your code! maybe use your attribute field value to know what kind of replacement you want to do...
            body.Emit(OpCodes.Ret);
 
            //define the replacement
            yield return new Advice(dynamicMethod);
        }
    }
