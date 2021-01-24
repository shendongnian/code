    else
                    if (!checkBoxAssociados.Checked)
                    {
                        ListItemTxt[0] = view.ViewType.ToString() + ": " + view.ViewName.ToString();
                        ListItemTxt[1] = " -  ";
                        ListItemTxt[2] = "Vista não Associada!      Clique aqui para Associar Vista"; //POR DEFEITO A VISTA NÃO ESTÁ ASSOCIADA
                        //VER SE A VISTA ESTÁ ASSOCIADA OU NAO
                        if (dicVistasFicheiroDesenho.ContainsKey(view.Id.IntegerValue))
                        {
                            ListItemTxt[2] = dicVistasFicheiroDesenho[view.Id.IntegerValue][0];//Designacao
                            ListItemTxt[1] = dicVistasFicheiroDesenho[view.Id.IntegerValue][1];//Referencia
                        }
                        ListItemTxt[3] = view.Id.IntegerValue.ToString();
                        ListViewItem lvi = new ListViewItem(ListItemTxt);
                        ListViewVistas.Items.Add(lvi);
                    }
                }
            }
            if (checkBoxSheets.Checked)
            {
                foreach (Autodesk.Revit.DB.ViewSheet viewSheet in m_selectViewsData.PrintableSheets)
                {
                    ListItemTxt[0] = viewSheet.ViewType.ToString() + ": " + viewSheet.SheetNumber + " - " +
                        viewSheet.ViewName.ToString();
                    ListItemTxt[1] = " -  ";
                    ListItemTxt[2] = "Vista não Associada!      Clique aqui para Associar Vista"; //POR DEFEITO A VISTA NÃO ESTÁ ASSOCIADA
                    //VER SE A VISTA ESTÁ ASSOCIADA OU NAO
                    if (dicVistasFicheiroDesenho.ContainsKey(viewSheet.Id.IntegerValue))
                    {
                        ListItemTxt[2] = dicVistasFicheiroDesenho[viewSheet.Id.IntegerValue][0];//Designacao
                        ListItemTxt[1] = dicVistasFicheiroDesenho[viewSheet.Id.IntegerValue][1];//Referencia 
                    }
                    ListItemTxt[3] = viewSheet.Id.IntegerValue.ToString();
                    ListViewItem lvi = new ListViewItem(ListItemTxt);
                    ListViewVistas.Items.Add(lvi);
                }
            }
            if (ListViewVistas.SelectedIndices.Count > 0)
            {
            }
