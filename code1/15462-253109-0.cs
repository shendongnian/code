        private void btnRemove_Click(object sender,EventArgs e)
        {
            int topIndex = listBox1.TopIndex;
            m_bList.Remove(listBox1.SelectedItem as ItemData);
            if(listBox1.Items.Count>topIndex)
                listBox1.TopIndex = topIndex;
        }
