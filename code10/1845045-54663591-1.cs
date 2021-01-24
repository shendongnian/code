    public void DoShowSomeProducts(Category category)
    {
        searchText.text = category.name;
        foreach (Transform each in GetComponentInChildren<LayoutGroup>().transform)
        {
            GameObject.Destroy(each.gameObject);
        }
        // parse product
        List<Item> productsInCategory = new List<Item>();
        //Tried the for loop logic here works well but didn't need it here.
        FirebaseDatabase.DefaultInstance.GetReference("Product").GetValueAsync().ContinueWith(task =>
        {
            if (task.IsFaulted)
            {
                Debug.Log("There is a fault");
            }
            else if (task.IsCompleted)
            {
                DataSnapshot snap = task.Result;
                if (snap.ChildrenCount > 0)
                {
                    foreach (var child in snap.Children)
                    {
                        print("Creating Item");
                        Item _item = new Item();
                        _item.url = child.Child("url").Value.ToString();
                        _item.image = child.Child("img").Value.ToString();
                        _item.code = child.Child("code").Value.ToString();
                        _item.price = child.Child("price").Value.ToString();
                        _item.category = child.Child("category").Value.ToString();
                        _item.descr = child.Child("descr").Value.ToString();
                        _item.link = child.Child("link").Value.ToString();
                        _item.name = child.Child("name").Value.ToString();
                        print("================================= \n Product\n" + _item.url + "\n" + _item.image + "\n" + _item.code + "\n" + _item.price
                              + "\n" + _item.category + "\n" + _item.descr + "\n" + _item.link + "\n" + _item.name + "\n===========================");
                        productsInCategory.Add(_item);
                        //Here tried to run the for loop logic using separate functions and co-routines.
                        print("Added Product");
                        Debug.Log(_item.category);
                    }
                    // pass the list to the download routine
                    StartCoroutine(DownloadImages(productsInCategory));
                }
            }
        });
    }
    private IEnumerator DownloadImages(List<Item> productsInCategory)
    {
        for (int i = 0; i < productsInCategory.Count; i++)
        {
            print("PinCat Count = " + productsInCategory.Count);
            Item item = productsInCategory[i];
            GameObject obj = Resources.Load<GameObject>("Prefabs/ProductButtonPrefab");
            GameObject clone = GameObject.Instantiate(obj);
            clone.transform.parent = GetComponentInChildren<LayoutGroup>().transform;
            clone.transform.localScale = Vector3.one;
            clone.GetComponent<ProductButton>().nameText.text = item.name;
            clone.GetComponent<ProductButton>().product = item;
            clone.GetComponent<ProductButton>().categoryText.text = item.category;
            clone.GetComponent<ProductButton>().priceText.text = item.price;
            clone.GetComponent<ProductButton>().nameText.text = item.name;
            print("Know Downloading Image");
            WWW www = new WWW(item.image);
            yield return www;
            // you should always debug things
            if (!string.IsNullOrEmpty(www.error))
            {
                Debug.LogErrorFormat(this, "Download failed for item {0} at index {1} due to: {2}", item.name, i, www.error);
                continue;
            }
            clone.GetComponent<ProductButton>().mainImage.sprite = Sprite.Create(www.texture, new Rect(0, 0, www.texture.width, www.texture.height), new Vector2(0, 0));
        }
    }
