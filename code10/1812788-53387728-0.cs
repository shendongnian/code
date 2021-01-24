    List<ClientImpressionProductSelectionM> ClientImpressionProdSelection = _customerPrintService.GetClientImpressionProductSelection().ToList();
    int index = 1;
    GetClientImpressionProductSel.Clear();               
    generateSeqNumber();
    
    foreach (var ProdSelection in ClientImpressionProdSelection)
    {
        for (index = 1; index <= InputProduct.NdPlettes;)
        {          
                ClientImpressionProductSelectionM prd = new ClientImpressionProductSelectionM();           
                prd.Sequence = Convert.ToInt32(GenResult);
                prd.Number = index;
                prd.ClientDestinataire = InputProduct.ClientDestinataire;
                prd.LieuDeLivraison = InputProduct.LieuDeLivraison;
                prd.CodeProduitClient = InputProduct.CodeProduitClient;
                prd.CodeCouleurClient = InputProduct.CodeCouleurClient;
                prd.CodeFournisseurEMPourClient = InputProduct.CodeFournisseurEMPourClient;
                prd.AQP = InputProduct.AQP;
                prd.Produit = InputProduct.Produit;
                prd.RefFournisseur = InputProduct.RefFournisseur;
                prd.NdShipment = InputProduct.NdShipment.Value;
                prd.NdLot = InputProduct.NdLot;
                prd.Cdate = InputProduct.Cdate;
                prd.PoidsNet = InputProduct.PoidsNet;
                prd.PoidsBrut = InputProduct.PoidsBrut;
                prd.NbrPallet = InputProduct.NdPlettes.Value;
                prd.Material = InputProduct.Material;
                prd.CodClient = InputProduct.CodClient;
                prd.CodPackaging = InputProduct.CodPackaging;
                prd.CoefNetBrut = InputProduct.CoefNetBrut;
                index++;
                GetClientImpressionProductSel.Add(prd);
        }
    
        CalculateGrossWeight(ProdSelection); 
    }
