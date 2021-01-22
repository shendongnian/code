    internal class ItemTemplateDefault : ITemplate
    {
        public void InstantiateIn(Control container)
        {
            Literal lit = new Literal();
            CountrySelectorItemContainer cont = container as CountrySelectorItemContainer;
            lit.Text = string.Format("<li>\n\t<a href=\"{0}\" title=\"{1}\">{1}</a>\n</li>", cont.ItemURL, cont.ItemText);
            container.Controls.Add(lit);
        }
    }
