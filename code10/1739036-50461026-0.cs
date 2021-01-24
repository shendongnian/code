    string typeName = args[0]; //"Dog";
    string formTypeFullName = string.Format("{0}.{1}", this.GetType().Namespace, typeName);
    Type type = Type.GetType(formTypeFullName, true);
    Dog dog = (Dog)Activator.CreateInstance(type);
    dog.Bark(int.Parse(args[1]));
