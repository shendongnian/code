        /// <summary>
        /// Function to get the string representations of the hierarchy List
        /// </summary>
        /// <param name="Items">The hierarchical list of items</param>
        /// <param name="depth">Depth to which the function should traverse. Passsing zero will make the function traverse throughout the heirarchy</param>
        /// <returns>List of string representing each hierarchy</returns>
        public List<string> GetChildren(List<Item> Items, int depth)
        {
            List<string> ReturnList = new List<string>();
            // Get Root Item
            Item rootItem = Items.FirstOrDefault(x => x.ParentId == 0);
            TraverseChildren(Items, rootItem, depth, 1, ReturnList, rootItem.Name);
            return ReturnList;
        }
        private void TraverseChildren(List<Item> items, Item rootItem, int depth, int currentLevel, List<string> hierarchyList, string hierarchyString)
        {
            // Return If current level is higher than Depth
            // And depth is non-zero
            if (currentLevel > depth && depth !=0) { return; }
            Item[] Children = items.Where(x => x.ParentId == rootItem.Id).ToArray();
            foreach (Item itm in Children)
            {
                string currentItemHeirarchyString = string.Format("{0}:{1}", hierarchyString, itm.Name);
                hierarchyList.Add(currentItemHeirarchyString);
                TraverseChildren(items, itm, depth, currentLevel + 1, hierarchyList, currentItemHeirarchyString);
            }
        }
