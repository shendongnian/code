    #region *** Рекруссия. treeView ***
            void CheckTrueTreeNode(TreeNodeCollection Nodes)
            {
                    foreach (TreeNode tn in Nodes)
                    {
                        if (tn.Checked == true)
                        {
                        // textBox1.Text += (tn.Name + " -**//**- " + path + tn.FullPath + "\r\n");  // инфо сообщение 
                        //treeView1.SelectedNode = null;
                        //treeView1.SelectedNode = tn;
                        //tn.EnsureVisible();
                        //return;
                        
                        // путь к выбранному файлу 
                        pathFileData = path + tn.FullPath;
     
                        // BackgroundWorker. Старт
                        bw_start();
     
                        }
     
                        CheckTrueTreeNode(tn.Nodes);
                    }
            }
            #endregion *** Рекруссия ***
