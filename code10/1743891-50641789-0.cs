       GLatLng mainLocation = new GLatLng(20.300000099999997, 50.4000000);
                 GMap1.setCenter(mainLocation, 15);
                 XPinLetter xpinLetter = new XPinLetter(PinShapes.pin_star, "S", Color.Blue, Color.White, Color.Chocolate);
                 GMap1.Add(new GMarker(mainLocation, new GMarkerOptions(new GIcon(xpinLetter.ToString(), xpinLetter.Shadow()))));
                GMap1.addControl(new GControl(GControl.preBuilt.GOverviewMapControl));
                GMap1.addControl(new GControl(GControl.preBuilt.LargeMapControl));
                GeoLocationDB objLocationDB = new GeoLocationDB();
                GeoLocationList objLocationList = new GeoLocationList();
                DateTime dt1 = new DateTime();
                dt1 = new DateTime(Convert.ToInt32(txtDatePicker.Text.Split('/')[2].ToString()), Convert.ToInt32(txtDatePicker.Text.Split('/')[1].ToString()), Convert.ToInt32(txtDatePicker.Text.Split('/')[0].ToString()));
                DateTime dt2 = new DateTime();
                dt2 = new DateTime(Convert.ToInt32(txtDatePicker1.Text.Split('/')[2].ToString()), Convert.ToInt32(txtDatePicker1.Text.Split('/')[1].ToString()), Convert.ToInt32(txtDatePicker1.Text.Split('/')[0].ToString()));
                objLocationList = objLocationDB.GetListBySearch(txtStaff.Text, dt1, dt2);
                PinIcon p;
                GMarker gm;
                GInfoWindow win;
                foreach (var i in objLocationList)
                {
                    p = new PinIcon(PinIcons.car, Color.Cyan);
                    string str = i.Latitude;
                    string[] values = str.Split(',');
                    for (int s = 0; s < 1; s++)
                    {
                        double lang =Convert.ToDouble(values[0].Trim());
                        double longi = Convert.ToDouble(values[1].Trim());
                        gm = new GMarker(new GLatLng(lang,longi),
                                 new GMarkerOptions(new GIcon(p.ToString(), p.Shadow())));
                   
                     win = new GInfoWindow(gm, i.ShopName + " <a href='" + i.Address + "'>Address...</a>", false, GListener.Event.mouseover);
                     GMap1.Add(win);
                    }
                }
