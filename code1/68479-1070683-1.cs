        private static void Display(string marker, IList<Content> content)
        {
            int count = 0;
            foreach (Content c in content)
            {
                string label = marker + (marker.Length > 0 ? "." : "") + (++count);
                Console.WriteLine(label + " " + c.Title);
                if (c.SubContent.Count > 0)
                    Display(label, c.SubContent);
            }
        }
