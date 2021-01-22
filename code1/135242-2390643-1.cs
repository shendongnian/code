        int AUTHORBOX = 2;
        int TITLEBOX = 4;
        int ISBNBOX = 8;
        int PRICEBOX = 16;
        public int AlternateCheck()
        {
            int temp = 0;
            temp += string.IsNullOrEmpty(authorbox.Text) ? AUTHORBOX : 0;
            temp += string.IsNullOrEmpty(titlebox.Text) ? TITLEBOX : 0;
            temp += string.IsNullOrEmpty(isbnbox.Text) ? ISBNBOX : 0;
            temp += string.IsNullOrEmpty(pricebox.Text) ? PRICEBOX : 0;
            return temp;
        }
