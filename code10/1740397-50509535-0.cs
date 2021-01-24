     oldList = oldList.Select(ele => { return (newList.Any(i => i.id == ele.id) ? ele.Copy(newList.FirstOrDefault(newObj => newObj.id == ele.id)) : ele); }).ToList();
    //Changes in your class
    public void Copy(Product prod)
    {
        //use req. property of prod. to be replaced the old class 
        this.id = prod.id;
    }
