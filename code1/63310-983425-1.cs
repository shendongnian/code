        Type myType = typeof(TestStruct);
        // Get the fields of TestStruct.
        FieldInfo[] myFieldInfo = 
            myType.GetFields(
               BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Public);
        Console.WriteLine("\nThe fields of TestStruct are \n");
        // Display the field information of TestStruct.
        for(int i = 0; i < myFieldInfo.Length; i++)
        {
            Console.WriteLine("\nName            : {0}", myFieldInfo[i].Name);
            Console.WriteLine("Declaring Type  : {0}", myFieldInfo[i].DeclaringType);
            Console.WriteLine("IsPublic        : {0}", myFieldInfo[i].IsPublic);
            Console.WriteLine("MemberType      : {0}", myFieldInfo[i].MemberType);
            Console.WriteLine("FieldType       : {0}", myFieldInfo[i].FieldType);
            Console.WriteLine("IsFamily        : {0}", myFieldInfo[i].IsFamily);
        }
