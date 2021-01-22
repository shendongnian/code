    private Element ReadMemberExpression()
    {
        var queue = new Queue<Element[]>();
        var newDepth = 0;
        var argsCount = 0;
        _scanner.CreateRestorePoint();
        while (true)
        {
            _scanner.CreateRestorePoint();
            {
                var a = ReadArguments();
                if (a != null)
                {
                    argsCount++;
                    if (argsCount > newDepth)
                    {
                        _scanner.Restore();
                        break;
                    }
                    queue.Enqueue(new[] { default(Element), default(Element), a });
                    _scanner.DeleteRestorePoint();
                    continue;
                }
            }
            _scanner.DeleteRestorePoint();
     
            var pe = ReadPrimaryExpression();
            if (pe != null)
            {
                queue.Enqueue(new[] { pe });
                continue;
            }
     
            var fe = ReadFunctionExpression();
            if (fe != null)
            {
                queue.Enqueue(new[] { fe });
                continue;
            }
     
            if (_scanner.MatchNext(Grammar.New))
            {
                newDepth++;
                queue.Enqueue(new[] { Grammar.New });
            }
            else if (_scanner.Match(Grammar.LeftSquareBracket))
            {
                var e = ReadExpression();
                if (e == null)
                {
                    throw new ParseException();
                }
                if (!_scanner.MatchNext(Grammar.RightSquareBracket))
                {
                    throw new ParseException();
                }
                queue.Enqueue(new[]{default(Element), Grammar.LeftSquareBracket, e, Grammar.RightSquareBracket});
            }
            else if (_scanner.Match(Grammar.FullStop))
            {
                if (!_scanner.MatchNext(ElementType.IdentifierName))
                {
                    throw new ParseException();
                }
                queue.Enqueue(new[] { default(Element), Grammar.FullStop, _scanner.Current });
            }
            else
            {
                _scanner.Unwind();
                break;
            }
        }
        if (queue.Count == 0)
        {
            _scanner.DeleteRestorePoint();
            return null;
        }
        else
        {
            var element = default(Element);
            var children = queue.Dequeue();
            while (children[0] == Grammar.New)
            {
                children = queue.Dequeue();
            }
            element = new Element(ElementType.MemberExpression, children);
            while (queue.Count > 0)
            {
                children = queue.Dequeue();
                if (children.Length == 3 && children[2].Type == ElementType.Arguments)
                {
                    newDepth--;
                    children[0] = Grammar.New;
                    children[1] = element;
                    element = new Element(ElementType.MemberExpression, children);
                }
                else
                {
                    children[0] = element;
                    element = new Element(ElementType.MemberExpression, children);
                }
            }
            if (newDepth > 0)
            {
                _scanner.Restore();
                return null;
            }
            _scanner.DeleteRestorePoint();
            return element;
        }
    }
