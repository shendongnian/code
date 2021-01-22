            private void ReadDxfFile (string DxfFile)
        {
            string Layer = "";
            string[] D = DxfFile.Split(new[] { Environment.NewLine }, StringSplitOptions.None);
            int iEntities = 0; for(int i = 0; i < D.Length; i++) { if (D[i] == "ENTITIES") {iEntities = i; break; } }
            for (int i = iEntities; i < D.Length; i++)
            {
                if (D[i] == "POINT" || D[i] == "AcDbPoint")
                {
                    int iEntity = i; if (D[i].StartsWith("AcDb")) { for (iEntity = i; D[iEntity] != "AcDbEntity"; iEntity--) ; }
                    Layer = ""; for (int iLayer = iEntity; iLayer < i + 10 && Layer == ""; iLayer++) { if (D[iLayer] == "  8") { Layer = D[iLayer + 1]; }; }
                    for (int iWaarden = i; iWaarden < i + 8; iWaarden++)
                    {
                        if (D[iWaarden] == " 10" && D[iWaarden + 2] == " 20")
                        {
                            //Here you can store the following data in a list for later use
                            //LayerName = Layer
                            //X = D[iWaarden + 1]
                            //Y = D[iWaarden + 3]
                            //Z = D[iWaarden + 5]
                        }
                    }
                }
                if (D[i] == "LINE" || D[i] == "AcDbLine")
                {
                    int iEntity = i; if (D[i].StartsWith("AcDb")) { for (iEntity = i; D[iEntity] != "AcDbEntity"; iEntity--) ; }
                    Layer = ""; for (int iLayer = iEntity; iLayer < i + 10 && Layer == ""; iLayer++) { if (D[iLayer] == "  8") { Layer = D[iLayer + 1]; }; }
                    for (int iWaarden = i; iWaarden < i + 10; iWaarden++)
                    {
                        if (D[iWaarden] == " 10" && D[iWaarden + 2] == " 20")
                        {
                            //Here you can store the following data in a list for later use
                            //LayerName = Layer
                            //Xbegin = D[iWaarden + 1]
                            //Ybegin = D[iWaarden + 3]
                            //Zbegin = D[iWaarden + 5]
                            //Xend = D[iWaarden + 7]
                            //Yend = D[iWaarden + 9]
                            //Zend = D[iWaarden + 11]
                        }
                    }
                }
                if (D[i] == "ARC" || D[i] == "AcDbArc" || D[i] == "AcDbCircle")
                {
                    int iEntity = i; if (D[i].StartsWith("AcDb")) { for (iEntity = i; D[iEntity] != "AcDbEntity"; iEntity--) ; }
                    Layer = ""; for (int iLayer = iEntity; iLayer < i + 10 && Layer == ""; iLayer++) { if (D[iLayer] == "  8") { Layer = D[iLayer + 1]; }; }
                    for (int iWaarden = i; iWaarden < i + 10; iWaarden++)
                    {
                        if (D[iWaarden] == " 10" && D[iWaarden + 2] == " 20" && D[iWaarden + 10] == " 51")
                        {
                            //Here you can store the following data in a list for later use
                            //LayerName = Layer
                            //Xmid = D[iWaarden + 1]
                            //Ymid = D[iWaarden + 3]
                            //Zmid = D[iWaarden + 5]
                            //Radius = D[iWaarden + 7]
                            //StartAngle = D[iWaarden + 9]
                            //StartAngle = D[iWaarden + 11]
                        }
                        if (D[iWaarden] == " 10" && D[iWaarden + 2] == " 20" && D[iWaarden + 12] == " 51")
                        {
                            //Here you can store the following data in a list for later use
                            //LayerName = Layer
                            //Xmid = D[iWaarden + 1]
                            //Ymid = D[iWaarden + 3]
                            //Zmid = D[iWaarden + 5]
                            //Radius = D[iWaarden + 7]
                            //StartAngle = D[iWaarden + 11]
                            //StartAngle = D[iWaarden + 13]
                        }
                    }
                }
            }
        }
