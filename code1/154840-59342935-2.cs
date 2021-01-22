    C#
    private void PopulatePager(int recordCount, int currentPage)
    {
        List<Page> pages = new List<Page>();
        int startIndex, endIndex;
        int pagerSpan = 5;
     
        //Calculate the Start and End Index of pages to be displayed.
        double dblPageCount = (double)((decimal)recordCount / Convert.ToDecimal(PageSize));
        int pageCount = (int)Math.Ceiling(dblPageCount);
        startIndex = currentPage > 1 && currentPage + pagerSpan - 1 < pagerSpan ? currentPage : 1;
        endIndex = pageCount > pagerSpan ? pagerSpan : pageCount;
        if (currentPage > pagerSpan % 2)
        {
            if (currentPage == 2)
            {
                endIndex = 5;
            }
            else
            {
                endIndex = currentPage + 2;
            }
        }
        else
        {
            endIndex = (pagerSpan - currentPage) + 1;
        }
     
        if (endIndex - (pagerSpan - 1) > startIndex)
        {
            startIndex = endIndex - (pagerSpan - 1);
        }
     
        if (endIndex > pageCount)
        {
            endIndex = pageCount;
            startIndex = ((endIndex - pagerSpan) + 1) > 0 ? (endIndex - pagerSpan) + 1 : 1;
        }
     
        //Add the First Page Button.
        if (currentPage > 1)
        {
            pages.Add(new Page { Text = "First", Value = "1" });
        }
     
        //Add the Previous Button.
        if (currentPage > 1)
        {
            pages.Add(new Page { Text = "<<", Value = (currentPage - 1).ToString() });
        }
     
        for (int i = startIndex; i <= endIndex; i++)
        {
            pages.Add(new Page { Text = i.ToString(), Value = i.ToString(), Selected = i == currentPage });
        }
     
        //Add the Next Button.
        if (currentPage < pageCount)
        {
            pages.Add(new Page { Text = ">>", Value = (currentPage + 1).ToString() });
        }
     
        //Add the Last Button.
        if (currentPage != pageCount)
        {
            pages.Add(new Page { Text = "Last", Value = pageCount.ToString() });
        }
     
        //Clear existing Pager Buttons.
        pnlPager.Controls.Clear();
     
        //Loop and add Buttons for Pager.
        int count = 0;
        foreach (Page page in pages)
        {
            Button btnPage = new Button();
            btnPage.Location = new System.Drawing.Point(38 * count, 5);
            btnPage.Size = new System.Drawing.Size(35, 20);
            btnPage.Name = page.Value;
            btnPage.Text = page.Text;
            btnPage.Enabled = !page.Selected;
            btnPage.Click += new System.EventHandler(this.Page_Click);
            pnlPager.Controls.Add(btnPage);
            count++;
        }
    }
     
    private void Page_Click(object sender, EventArgs e)
    {
        Button btnPager = (sender as Button);
        this.BindGrid(int.Parse(btnPager.Name));
    }
     
    public class Page
    {
        public string Text { get; set; }
        public string Value { get; set; }
        public bool Selected { get; set; }
    }
