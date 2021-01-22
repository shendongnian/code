        private delegate bool RemovalExpression(ItemType item);
        private void RemoveItems(RemovalExpression shouldRemove)
        {
            for (int s = 0; s < itemList.Count; s++)
            {
                if (shouldRemove(itemList[s]))
                {
                    RemoveItem(itemList[s].Id);
                    itemList.RemoveAt(s);
                    s--;
                }
            }
        }
