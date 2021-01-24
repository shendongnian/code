    #region  *** TreeView Создание***
            private void InitFolders()
            {
                //Отключаем любую перерисовку
                //иерархического представления.
                treeView1.BeginUpdate();
     
                //Инициализируем новую переменную предоставляющую методы экземпляра
                //класса для создания, перемещения и перечисления
                //в каталогах и подкаталогах.
                System.IO.DirectoryInfo di;
                try
                {
                    //Вызываем метод GetDirectories с передачей в качестве параметра, пути к 
                    //выбранной директории. Данный метод возвращает
                    //массив имен подкаталогов.
                    string[] root = System.IO.Directory.GetDirectories(path);
     
                    //Проходимся по всем полученным подкаталогам.
                    foreach (string s in root)
                    {
                        try
                        {
                            //Заносим в переменную информацию
                            //о текущей директории.
                            di = new System.IO.DirectoryInfo(s);
                            //Вызов метода сканирования с
                            //передачей в качестве параметра, информации
                            //о текущей директории и объект 
                            //System.Windows.Forms.TreeNodeCollection,
                            //который предоставляет узлы
                            //дерева, назначенные элементу управления 
                            //иерархического представления.
                            BuildTree(di, treeView1.Nodes);
                        }
                        catch { }
                    }
                }
                catch { }
                //Разрешаем перерисовку иерархического представления.
                treeView1.EndUpdate();
            }       
     
            //Процесс получения папок и файлов
            private void BuildTree(System.IO.DirectoryInfo directoryInfo, TreeNodeCollection addInMe)
            {
                //Добавляем новый узел в коллекцию Nodes
                //с именем текущей директории и указанием ключа 
                //со значением "Folder".
                TreeNode curNode = addInMe.Add("Folder", directoryInfo.Name);
     
                //addInMe.Add(directoryInfo.FullName, directoryInfo.Name, 
                //тут можно указать номер картинки для узла из imageCollection);
     
                //Перебираем папки.
                foreach (System.IO.DirectoryInfo subdir in directoryInfo.GetDirectories())
                {
                    //Запускам процесс получения папок и файлов 
                    //с текущей найденной директории.
                    BuildTree(subdir, curNode.Nodes);
                }
     
                //Перебираем файлы
                foreach (System.IO.FileInfo file in directoryInfo.GetFiles())
                {
                    //Добавляем новый узел в коллекцию Nodes
                    //С именем текущей директории и указанием ключа 
                    //со значением "File".
                    curNode.Nodes.Add("File", file.Name);
     
                    //curNode.Nodes.Add("File", file.Name, 
                    //тут можно указать номер картинки для узла из imageCollection);  
                }
            }
            #endregion *** TreeView ***
