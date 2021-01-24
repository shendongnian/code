            var myTraceFloats = new System.Collections.Generic.List<float>();
            if (!string.IsNullOrEmpty(myTrace))
            {
                foreach (var item in myTrace.Split(' '))
                {
                    float floatItem;
                    if (float.TryParse(item, out floatItem))
                    {
                        myTraceFloats.Add(floatItem);
                    }
                }
            }
