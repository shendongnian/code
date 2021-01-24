    public void LoadAsstBundles(int choice)
            {
                if(choice==1)
                {
                    _assetname = "Chair1";
                }
                else if(choice == 2)
                {
                    _assetname = "Chair2";
                }
                else if(choice == 3)
                {
                    _assetname = "Chair3";
        
                }
        if (_assetsBundle==null)
        {
            Debug.Log("Could Not load AssetBundles");
        }
        else
        {
            
           var asset= _assetsBundle.LoadAsset(_assetname);
            //if (GameObject.Find(_assetname + "(Clone)"))
            //{
            //    Debug.Log("Already Loaded");
            //}
            if(ParentTransform.Find(_assetname+ "(Clone)")== true)
            {
                Debug.Log("Already Loaded");
                int childcount = ParentTransform.childCount;
                for (int i = 0; i < childcount; i++)
                {
                    if (choice == i)
                    {
                        ParentTransform.GetChild(i).gameObject.SetActive(true);
                        continue;
                    }
                    ParentTransform.GetChild(i).gameObject.SetActive(false);
                }
            }
            else
            {
                Debug.Log("Asset Bundles Loaded");
                var go = (GameObject)Instantiate(asset, ParentTransform);
                int option = go.transform.GetSiblingIndex();
                _loadednames.Add(go.name);
                Debug.Log("Sibling index == " + go.transform.GetSiblingIndex());
                int childcount = ParentTransform.childCount;
                for (int i = 0; i < childcount; i++)
                {
                    if (option == i)
                    {
                        ParentTransform.GetChild(i).gameObject.SetActive(true);
                        continue;
                    }
                    ParentTransform.GetChild(i).gameObject.SetActive(false);
                }
            }
        }
    }
