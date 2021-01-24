     var removeColumn = target.Columns.OfType<Column>().Where(x => !source.Columns.Contains(x.Name)).ToList();
     foreach (Column columItem in removeColumn)
            {
                 //If you want remove this item just replace Remove to SetState  
                columItem.SetState(SqlSmoState.ToBeDropped);
                //If I use Remove will got You cannot perform operation Remove on an object in state Existing
                //target.Columns.Remove(columItem.Name);
            }
