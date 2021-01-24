         private void btnApply_Click(object sender, RoutedEventArgs e)
        {
            //ApplyGeneralChanges();
            var item = this.FindResource("ClassName") as ClassName;
            item.DisplayDeleted = !item.DisplayDeleted;
        }
