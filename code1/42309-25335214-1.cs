            // Generating lists in a loop.
            List<List<string>> biglist = new List<List<string>>();
            for(int i = 1; i <= 10; i++)
            {
                List<string> list1 = new List<string>();
                biglist.Add(list1);
            }
            // Populating the lists
            for (int i = 0; i < 10; i++)
            {
                for(int j = 0; j < 10; j++)
                {
                    biglist[i].Add((i).ToString() + " " + j.ToString());
                }
            }
            textbox1.Text = biglist[5][9] + "\n";
