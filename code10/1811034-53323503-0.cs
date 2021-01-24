    private void ShowTree(List<Entities.Entities.Element> elements)
    {
        for (int i = 0; i < elements.Count(); i++)
        {
            if (elements[i].ParentElementId.HasValue)
            {
                elements[i].Reference = $"{elements[i].ParentElement.Reference}.{i+1}";
            }
            if (elements[i].ChildElements.Any())
            {
                foreach (var child in elements[i].ChildElements)
                {
                     child.ParentElement = elements[i];
                }
                this.ShowTree(elements[i].ChildElements.ToList());
            }
        }
    }
