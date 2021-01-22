    private void BuildUpChildren(List<Node> list)
            {
                foreach (Node item in list)
                {
                    List<Node> nodes = GetNodesByParent(item.Id);
                    item.Nodes.AddRange(nodes);
                    BuildUpChildren(nodes);
                }
    }
