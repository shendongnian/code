    Public static bool deleteElement(OpenXmlElement parentElement, OpenXmlElement elem, string id, bool seekParent)
    {
        bool found = false;
        //Loop until I find BookmarkEnd or null element
        while (!found && elem != null && (!(elem is BookmarkEnd) || (((BookmarkEnd)elem).Id.Value != id)))
        {
            if (elem.ChildElements != null && elem.ChildElements.Count > 0)
            {
                found = deleteElement(elem, elem.FirstChild, id, false);
            }
            if (!found)
            {
                OpenXmlElement nextElem = elem.NextSibling();
                elem.Remove();
                elem = nextElem;
            }
        }
        if (!found)
        {
            if (elem == null)
            {
                if (!(parentElement is Body) && seekParent)
                {
                    //Try to find bookmarkEnd in Sibling nodes
                    found = deleteElement(parentElement.Parent, parentElement.NextSibling(), id, true);
                }
            }
            else
            {
                if (elem is BookmarkEnd && ((BookmarkEnd)elem).Id.Value == id)
                {
                    found = true;
                }
            }
        }
        return found;
    }
