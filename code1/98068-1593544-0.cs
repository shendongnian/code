           object result = null;
            using (StreamReader reader = new StreamReader(ASSEMBLYPATH, Encoding.GetEncoding(1252), false))
            {
                byte[] b = new byte[reader.BaseStream.Length];
                reader.BaseStream.Read(b, 0, Convert.ToInt32(reader.BaseStream.Length));
                reader.Close();
                Assembly asm = AppDomain.CurrentDomain.Load(b);
                Type typeClass = asm.GetType(CLASSFULLNAME); // including namespace
                MethodInfo mi = typeClass.GetMethod("OnStart");
                ConstructorInfo ci = typeClass.GetConstructor(Type.EmptyTypes);
                object responder = ci.Invoke(null);
                // set parameters
                object[] parameters = new object[1];
                parameters[0] = null;  // no params
                result = mi.Invoke(responder, parameters);
            }
