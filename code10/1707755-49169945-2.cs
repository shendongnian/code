    private void UpdatePostCategories(Question question, string[] techIds)
    {
        var selectedCategoriesHS = new HashSet<string>(techIds);
        var postCategories = new HashSet<int>
               (question.Technologies.Select(t=> t.Id));
            foreach (var item in _context.Technologies)
            {
                if (selectedCategoriesHS.Contains(item.Id.ToString()))
                {
                    if (!postCategories.Contains(item.Id))
                    {
                        question.Technologies.Add(item);
                    }
                }
                else
                {
                    if (postCategories.Contains(item.Id))
                    {
                        question.Technologies.Remove(item);
                    }
                }
            }
        }
