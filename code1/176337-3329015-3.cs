    object[] primitiveData = new object[bytDate.Lenght];
    for (int i = 0; i < bytesDate.Lenght; i++)
    {
         Type t = types[i];
         if (t == typeof(int))
         {
              primitiveData[i] = Convert.ToInt32(bytesDate[i]);
         }
         else if (t == typeof(short))
         {
              primitiveData[i] = Convert.ToInt16(bytesDate[i]);
         }
         ..
    }
