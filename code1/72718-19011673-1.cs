            int size = HttpContext.Current.Items.Count;
            if (size > 0)
            {
                var keys = new object[size];
                HttpContext.Current.Items.Keys.CopyTo(keys, 0);
                for (int i = 0; i < size; i++)
                {
                    var obj = HttpContext.Current.Items[keys[i]] as IDisposable;
                    if (obj != null)
                        obj.Dispose();
                }
            }
