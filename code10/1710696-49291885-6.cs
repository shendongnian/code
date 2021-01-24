        private void AddToList(string text1, string text2) {
            listOfPersonState.Add(new PersonState { Name = text1, State = text2 });
        }
        private void UpdateToList(string text1, string text2) {
            int index = dataGridView1.SelectedRows[0].Index;
            listOfPersonState[index] = new PersonState { Name = text1, State = text2 };
        }
        private void DeleteToList() {
            int index = dataGridView1.SelectedRows[0].Index;
            listOfPersonState.RemoveAt(index);
        }
