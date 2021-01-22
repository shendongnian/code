       List<System.Drawing.Image> images = new List<System.Drawing.Image>();
            foreach (System.Reflection.MethodInfo t 
                in typeof(Resources.Resource).GetMethods())
            {
                if (t.ReturnType.ToString() == "System.Drawing.Bitmap")
                {
                    images.Add(new System.Drawing.Bitmap((System.Drawing.Image)t.Invoke(null, null)));
                    
                }
            }
