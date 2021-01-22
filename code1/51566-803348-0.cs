        public class HtmlPart {
            public void Render(object obj) {
                FieldInfo[] infos = obj.GetType().GetFields(BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance);
                foreach (var fi in infos)
                {
                    if (fi.GetValue(obj) == this && fi.IsDefined(typeof(OptionalAttribute), true))
                        Console.WriteLine("Optional is Defined");
                }
            }
        }
