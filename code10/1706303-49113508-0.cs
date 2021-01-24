    string SearchDomain="youdial.in";
    for (int i = 0; i < ListBox2.Items.Count; i++)
                {
                    var UrlList = new Uri(ListBox2.Items[i].ToString());
                    var UrlList = UrlList.Host;
                    if (UrlList == SearchDomain)
                    {
                        ListBox2.SelectedIndex = i;
                        urllbl.Text = ListBox2.SelectedItem.ToString();
                        break;
                    }
                }
