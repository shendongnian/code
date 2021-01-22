    using (IEnumerator<MyClass> classesEnum = myClasses.GetEnumerator()) {
        using (IEnumerator<MyClass> classesEnum2 = myClasses2.GetEnumerator()) {
            while (classesEnum.MoveNext() && classEnum2.MoveNext())
                Console.WriteLine("{0}, {1}", classesEnum.Current, classesEnum2.Current);
        }
    }
