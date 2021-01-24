        public delegate void DeleteClick(int id);
        public static event DeleteClick OnDeleteClick;
        private void Button_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            OnDeleteClick?.Invoke(((ChatListItemViewModel)this.DataContext).Id);
        }
