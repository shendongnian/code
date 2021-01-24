        private void btnPost_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtName.Text) || string.IsNullOrEmpty(txtReview.Text))
                return;
            //First we should set Model data
            Model.AddReview("moive1", txtName.Text, txtReview.Text);
            LoadListView();
        }
        private void AddReviewForm_Load(object sender, EventArgs e)
        {
            LoadListView();
        }
        private void LoadListView()
        {
            listView1.Clear();
            foreach (string reviewKey in Model.ReviewData.Keys)
            {
                Review review = Model.ReviewData[reviewKey];
                ListViewItem item = new ListViewItem(review.reviewerName);
                item.SubItems.Add(review.review);
                listView1.Items.Add(item);
            }
        }
