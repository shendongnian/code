    private void guncellemeIslemGecmisiGoster()
            {
                dt = db.TumGuncellemeIslemGecmisiGetir();
    
    
    
                dgwIslemGecmisi.Invoke(new Action(() => dgwIslemGecmisi.DataSource = dt));
                dgwIslemGecmisi.Invoke(new Action(() => dgwIslemGecmisi.Update()));
    
    
               
                dt.Dispose();
            }
