      /// <summary>
      /// Clones Any Object.
      /// </summary>
      /// <param name="objectToClone">The object to clone.</param>
      /// <return>The Clone</returns>
      public static Object Clone(Object objectToClone)
      {
         Object cloned_obj = null;
         if (objectToClone != null)
         {
            System.Runtime.Serialization.Formatters.Binary.BinaryFormatter bin_formatter = null;
            Byte[] obj_bytes = null;
            using (MemoryStream memory_stream = new MemoryStream(1000))
            {
               bin_formatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
               try
               {
                  bin_formatter.Serialize(memory_stream, objectToClone);
               }
               catch (SerializationException ex) { }
               obj_bytes = memory_stream.ToArray();
            }
            using (MemoryStream memory_stream = new MemoryStream(obj_bytes))
            {
               try
               {
                  cloned_obj = bin_formatter.Deserialize(memory_stream);
               }
               catch (SerializationException ex) { }
            }
         }
         return cloned_obj;
      }
