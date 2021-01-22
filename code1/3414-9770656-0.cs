        {
            bool status = false;
            if (list != null)
            {
                int flag = 0;
                var property = GetProperty(list.FirstOrDefault(), attribute);
                foreach (T obj in list)
                {
                    if (property.GetValue(obj, null) == null)
                        flag++;
                }
                status = flag == 0 ? true : false;
            }
            return status;
        }
