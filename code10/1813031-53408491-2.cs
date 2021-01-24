    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Linq;
    using System.Windows.Data;
    namespace TestWpfApplication
    {
        internal class MainWindowViewModel
        {
            private readonly List<Category> _categories;
            public MainWindowViewModel()
            {
                _categories = new List<Category>
                {
                    new Category {Code = 1, Description = "Blah"},
                    new Category {Code = 1, Description = "Blah"},
                    new Category {Code = 2, Description = "Pop"},
                    new Category {Code = 3, Description = "No"},
                    new Category {Code = 3, Description = "No"},
                    new Category {Code = 4, Description = "Yes"}
                };
                HookUpCategoryEvents();
                CategoryCollection = CollectionViewSource.GetDefaultView(_categories);
                CategoryCollection.Filter = OnlyShowIfMoreThanOne;
            }
            private bool OnlyShowIfMoreThanOne(object obj)
            {
                 Category item = obj as Category;
                 return _categories.Count(c => c.Code == item.Code) > 1;
            }
            public ICollectionView CategoryCollection { get; }
            private void HookUpCategoryEvents()
            {
                // If you add items or remove them at any point then you need to call this method
                // It removes the event so you don't get existing items being 'hooked up' double or more times
                foreach (var category in _categories)
                {
                    category.CodeChanged -= CategoryOnCodeChanged;
                    category.CodeChanged += CategoryOnCodeChanged;
                }
             }
            private void CategoryOnCodeChanged(object sender, EventArgs e)
            {
                CategoryCollection.Refresh();
            }
        }
    }
