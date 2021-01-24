     Dictionary<string, int> dic = new Dictionary<string, int>();
            foreach (var line in lines)
            {
                string[] str = line.Split('=');
                var num= str[1].Replace("$",""); // for seperate $ and number
                dic.Add(str[0], (Convert.ToInt32(num)));
            }
            foreach(var sortItem in dic.OrderBy(x=>x.Value))
            {
                listBox1.Items.Add(sortItem .Key + " = "+ sortItem .Value.ToString() + "$");
            }
