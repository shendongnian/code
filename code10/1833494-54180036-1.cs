    /// <summary>
    /// Make a point that gives a location at the given coordinates in the form
    /// independent of the current scroll position
    /// </summary>
    private Point MakeAbsolutePosition(int x, int y)
    {
        Point result = new Point(x + AutoScrollPosition.X, y + AutoScrollPosition.Y);
        return result;
    }
    private void btnEkle_Click(object sender, EventArgs e)
    {
        TextBox isimTb = new TextBox();
        TextBox fiyatTb = new TextBox();
        Label urunLbl = new Label();
        int positionNo = formNo;
        isimTb.Name = "isimBox" + formNo.ToString();
        isimTb.Location = MakeAbsolutePosition(125, ((positionNo - 1) * 25));
        isimTb.Width = 200;
        isimTb.Text = "Ürün İsmini Giriniz";
        fiyatTb.Name = "fiyatBox" + formNo.ToString();
        fiyatTb.Location = MakeAbsolutePosition(350, (positionNo - 1) * 25);
        fiyatTb.Width = 200;
        fiyatTb.Text = "Ürün Fiyatını Giriniz";
        urunLbl.Name = "label" + formNo.ToString();
        urunLbl.Text = formNo.ToString() + ". Ürün";
        urunLbl.Location = MakeAbsolutePosition(10, (positionNo - 1) * 25);
        urunLbl.Width = 100;
        this.Controls.Add(urunLbl);
        this.Controls.Add(isimTb);
        this.Controls.Add(fiyatTb);
        // TODO: Use the correct x values here
        btnEkle.Location = MakeAbsolutePosition(100, (positionNo - 1) * 25 + 50);
        btnKaydet.Location =MakeAbsolutePosition(200,  (positionNo - 1) * 25 + 50);
        formNo++;
    }
