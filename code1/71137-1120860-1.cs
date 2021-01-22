    using System;
    using System.Reflection;
    class ClassA {
      public byte b;
      public short s; 
      public int i;
    }
    class ClassB {
      public long l;
      public ClassA x;
    }
    class MainClass {
      public static void Main() {
        ClassB myBObject = new ClassB();
        WriteFields(myBObject.GetType(), 0);
      }
      static void WriteFields(Type type, Int32 indent) {
        foreach (FieldInfo fieldInfo in type.GetFields(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic)) {
          Console.WriteLine("{0}{1}\t{2}", new String('\t', indent), fieldInfo.FieldType.Name, fieldInfo.Name);
          if (fieldInfo.FieldType.IsClass)
            WriteFields(fieldInfo.FieldType, indent + 1);
        }
      }
    }
