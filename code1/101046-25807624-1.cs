        public class SingleClickEditDataGridCellBehavior:Behavior<DataGridCell>, IBehaviorCreator
        {
            //some code ...
            public Behavior Create()
            {
                // here of course you can also set properties if required
                return new SingleClickEditDataGridCellBehavior();
            }
        }
