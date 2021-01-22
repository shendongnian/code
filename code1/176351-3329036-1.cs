      [TestMethod]
      public void MyTestMethod() {
         byte[] byteData = new byte[] { 0xa0, 0x14, 0x72, 0xbf, 0x72, 0x3c, 0x21 };
         Type[] types = new Type[] { typeof(int), typeof(short), typeof(sbyte) };
         List<Array> result = new List<Array>();
         foreach (var type in types) {
            Type arrayType = type.MakeArrayType();
            ConstructorInfo ctor = arrayType.GetConstructor(new Type[] { typeof(int) });
            Array array = (Array)ctor.Invoke(new object[] { byteData.Length });
            for (int i = 0; i < byteData.Length; i++) {
               byte b = byteData[i];
               try {
                  array.SetValue(Convert.ChangeType(b, type), i);
               } catch {
                  Console.WriteLine("Error with type {0} and value {1}", type, b);
               }
            }
            result.Add(array);
         }
         // -------------------
         // show result
         foreach (var array in result) {
            Console.WriteLine(array.GetType());
            foreach (var item in array) {
               Console.WriteLine("   {0}", item);
            }
         }
      }
