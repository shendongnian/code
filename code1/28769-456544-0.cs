    using (IEnumerator<MyClass> classesEnum = myClasses.GetEnumerator()) {
        if (classEnum.MoveNext())
            Console.WriteLine(classesEnum.Current);
        while (classesEnum.MoveNext()) {
            Console.WriteLine("-----------------");
            Console.WriteLine(classesEnum.Current);
        }
    }
