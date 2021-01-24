    List<int> takeFrom = new List<int> { 2, 4, 6, 7, 8, 9, 10 };
        List<int> mustInclude = new List<int> { 1, 3, 5 };
        protected void Page_Load(object sender, EventArgs e)
        {
            List<List<int>> FinalList = new List<List<int>>();
            FinalList = GetAllCombos(takeFrom);
            FinalList = AddListToEachList(FinalList, mustInclude);
            gvCombos.DataSource = FinalList;
            gvCombos.DataBind();
        }
        // Recursive
        private static List<List<T>> GetAllCombos<T>(List<T> list)
        {
            List<List<T>> result = new List<List<T>>();
            // head
            result.Add(new List<T>());
            result.Last().Add(list[0]);
            if (list.Count == 1)
                return result;
            // tail
            List<List<T>> tailCombos = GetAllCombos(list.Skip(1).ToList());
            tailCombos.ForEach(combo =>
            {
                result.Add(new List<T>(combo));
                combo.Add(list[0]);
                result.Add(new List<T>(combo));
            });
            return result;
        }
        private static List<List<int>> AddListToEachList(List<List<int>> listOfLists, List<int> mustInclude)
        {
            List<List<int>> newListOfLists = new List<List<int>>();
            //Go through each List
            foreach (List<int> l in listOfLists)
            {
                List<int> newList = l.ToList();
                //Add each item that should be in all lists
                foreach(int i in mustInclude)
                    newList.Add(i);
                newListOfLists.Add(newList);
            }
            return newListOfLists;
        }
        protected void gvCombos_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                List<int> drv = (List<int>)e.Row.DataItem;
                Label lblCombo = (Label)e.Row.FindControl("lblCombo");
                foreach (int i in drv)
                    lblCombo.Text += string.Format($"{i} "); 
            }
        }
