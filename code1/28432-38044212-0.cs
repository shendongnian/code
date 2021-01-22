        public void MoveUp(object item,List Concepts){
            int ind = Concepts.IndexOf(item.ToString());
            if (ind != 0)
            {
                Concepts.RemoveAt(ind);
                Concepts.Insert(ind-1,item.ToString());
                obtenernombres();
                NotifyPropertyChanged("Concepts");
            }}
