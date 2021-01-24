        var roots = new List<RootNode>();
        foreach (var root in grouped3)
        {
            var rootNode = new RootNode(root.Key.RootType);
            roots.Add(rootNode);
            foreach (var sub in root)
            {
                var subNode = new SubNode(sub.Key.SubType);
                rootNode.AddSub(subNode);
                foreach (var item in sub)
                {
                    var itemNode = new ItemNode(item.Key.DisplayName);
                    subNode.AddItem(itemNode);
                    foreach (var payload in item)
                    {
                        var x = payload;
                        itemNode.AddPayload(payload.Payload as Payload);
                    }
                }
            }
        }
