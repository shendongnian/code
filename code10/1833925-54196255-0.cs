        public IEnumerator<BVHNode<BoundingVolumeClass>> GetEnumerator()
        {
            return rootNode == null
              ? Enumerable.Empty<BVHNode<BoundingVolumeClass>>().GetEnumerator()
              : rootNode.GetEnumerator();
        }
