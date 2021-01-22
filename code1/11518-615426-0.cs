        static void WriteThreadInfo(StringBuilder sw, IEnumerable<Thread> threads)
        {
            foreach(Thread thread in threads)
            {
                if(!thread.IsAlive) continue;
                sw.Append(String.Concat("THREAD NAME: ", thread.Name));
                sw.Append(GetStackTrace(thread));
                sw.AppendLine();
                sw.AppendLine();
            }
        }
        static String GetStackTrace(Thread t)
        {
            t.Suspend();
            var trace1 = new StackTrace(t, true);
            t.Resume();
            String  text1 = System.Environment.NewLine;
            var builder1 = new StringBuilder(255);
            for (Int32 num1 = 0; (num1 < trace1.FrameCount); num1++)
            {
                StackFrame  frame1 = trace1.GetFrame(num1);
                builder1.Append("   at ");
                System.Reflection.MethodBase  base1 = frame1.GetMethod();
                Type  type1 = base1.DeclaringType;
                if (type1 != null)
                {
                    String  text2 = type1.Namespace;
                    if (text2 != null)
                    {
                        builder1.Append(text2);
                        builder1.Append(".");                                                
                    }
                    builder1.Append(type1.Name);
                    builder1.Append(".");
                }
                builder1.Append(base1.Name);
                builder1.Append("(");
                System.Reflection.ParameterInfo [] infoArray1 = base1.GetParameters();
                for (Int32 num2 = 0; (num2 < infoArray1.Length); num2++)
                {
                    String text3 = "<UnknownType>";
                    if (infoArray1[num2].ParameterType != null)
                    {
                                    text3 = infoArray1[num2].ParameterType.Name;
                    }
                    builder1.Append(String.Concat(((num2 != 0) ? ", " : ""), text3, " ", infoArray1[num2].Name));
                }
                builder1.Append(")");
                if (frame1.GetILOffset() != -1)
                {
                    String text4 = null;
                    try
                    {
                        text4 = frame1.GetFileName();
                    }
                    catch (System.Security.SecurityException)
                    {
                    }
                    if (text4 != null)
                    {
                        builder1.Append(String.Concat(" in ", text4, ":line ", frame1.GetFileLineNumber().ToString()));
                    }
                }
                if (num1 != (trace1.FrameCount - 1))
                {
                    builder1.Append(text1);
                }
            }
            return builder1.ToString();
        }
