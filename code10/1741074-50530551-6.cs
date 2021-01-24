    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Text;
    
    namespace Question_Answer_Console_App
    {
        class Program
        {
            private const string ShortTab = "  ";
            private static readonly List<object> ListOfObjects = new List<object>()
            {
                4,
                "Michael",
                new object(),
                new Program(),
                69.4,
                new List<string>() {"Mathew", "Mark", "Luke", "John" },
                new int[] { 1, 3, 5, 7, 9 }
            };
    
            static void Main(string[] args)
            {
                var itemsText = new StringBuilder();
                var arrayCounter = 0;
    
                foreach (var item in ListOfObjects)
                {
                    if (item is IEnumerable enumeration)
                    {
                        itemsText.AppendLine($"Array: {++arrayCounter}");
                        if (item is string text)
                        {
                            itemsText.AppendLine($"{ShortTab}{text}");
                        }
                        else
                        {
                            foreach (var innerItem in enumeration) itemsText.AppendLine($"{ShortTab}{innerItem.ToString()}");
                        }
                    }
                }
                Console.WriteLine(itemsText.ToString());
                Console.Read();
            }
        }
    }
