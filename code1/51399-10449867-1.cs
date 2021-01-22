    [Test]
    public void SortStable()
    {
        var list = new List<SortItem>
                        {
                            new SortItem{ SortOrder = 1, Name = "Name1"},
                            new SortItem{ SortOrder = 2, Name = "Name2"},
                            new SortItem{ SortOrder = 2, Name = "Name3"},
                        };
            
        list.SortStable();
        Assert.That(list.ElementAt(0).SortOrder, Is.EqualTo(1));
        Assert.That(list.ElementAt(0).Name, Is.EqualTo("Name1"));
        Assert.That(list.ElementAt(1).SortOrder, Is.EqualTo(2));
        Assert.That(list.ElementAt(1).Name, Is.EqualTo("Name2"));
        Assert.That(list.ElementAt(2).SortOrder, Is.EqualTo(2));
        Assert.That(list.ElementAt(2).Name, Is.EqualTo("Name3"));
    }
    private class SortItem : IComparable<SortItem>
    {
        public int SortOrder { get; set; }
        public string Name { get; set; }
        public int CompareTo(SortItem other)
        {
            return SortOrder.CompareTo(other.SortOrder);
        }
    }
