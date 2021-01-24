        public void HighlightTile()
        {
            Vector3 mouse = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            foreach (SpriteInfo sprite in GetComponentsInChildren<SpriteInfo>())
            {
				SpriteRenderer renderer = sprite.GetComponent<SpriteRenderer>();
                if (renderer.bounds.Contains(mouse))
                    renderer.color = Color.red;
            }
        }
