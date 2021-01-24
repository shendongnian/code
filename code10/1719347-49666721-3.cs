    /// <summary>Priority Queue data structure.</summary>
    /// <remarks>
    /// Implemented in traditional fashion, using a heap.
    /// Based on code from http://www.vcskicks.com/priority-queue.php
    /// 
    /// Also see http://en.wikipedia.org/wiki/Heap_(data_structure)
    /// and http://en.wikipedia.org/wiki/Priority_queue
    /// </remarks>
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1711:IdentifiersShouldNotHaveIncorrectSuffix")]
    public sealed class PriorityQueue<T>
    {
        /// <summary>Constructor.</summary>
        /// <param name="comparer">A comparison function for items of type T>.</param>
        public PriorityQueue(Comparison<T> comparer)
        {
            _comparer = comparer;
            _heap = new List<T> {default(T)};
        }
        /// <summary>The number of items in the queue.</summary>
        public int Count => _heap.Count - 1;
        /// <summary>
        /// Returns the value at the head of the Priority Queue without removing it.
        /// Throws an exception if the queue is empty.
        /// </summary>
        public T Peek()
        {
            if (this.Count > 0)
            {
                return _heap[1]; // Head of the queue is at [1], not [0].
            }
            else
            {
                throw new InvalidOperationException("Attempt to Peek() into an empty PriorityQueue<T>");
            }
        }
        /// <summary>Adds a value to the Priority Queue</summary>
        public void Enqueue(T value)
        {
            _heap.Add(value);
            this.bubbleUp(_heap.Count - 1); // Bubble up to preserve the heap property, starting at the inserted value.
        }
        /// <summary>Returns the front of the Priority Queue.</summary>
        public T Dequeue()
        {
            if (this.Count > 0)
            {
                T minValue = this._heap[1]; // The smallest value in the Priority Queue is the first item in the array
                if (this._heap.Count > 2) // If there's more than one item, replace the first item in the array with the last one.
                {
                    T lastValue = this._heap[_heap.Count - 1];
                    this._heap.RemoveAt(_heap.Count - 1);       // Move last node to the head
                    this._heap[1] = lastValue;
                    this.bubbleDown(1);
                }
                else  // Only one item in the queue.
                {
                    _heap.RemoveAt(1);  // Remove the only value stored in the queue.
                }
                return minValue;
            }
            else
            {
                throw new InvalidOperationException("Attempt to Dequeue() from an empty PriorityQueue<T>");
            }
        }
        /// <summary>Restores the heap-order property between child and parent values going up towards the head.</summary>
        private void bubbleUp(int startCell)
        {
            // Requires(startCell >= 0);
            // Requires(startCell < _heap.Count);
            int cell = startCell;
            while (this.isParentBigger(cell))   // Bubble up as long as the parent is greater.
            {
                // Get values of parent and child.
                T parentValue = this._heap[cell/2];
                T childValue  = this._heap[cell];
                // Swap the values.
                this._heap[cell/2] = childValue;
                this._heap[cell]   = parentValue;
                cell /= 2; // Go up parents.
            }
        }
        /// <summary>Restores the heap-order property between child and parent values going down towards the bottom.</summary>
        private void bubbleDown(int startCell)
        {
            // Requires(startCell > 0);
            // Requires(startCell < _heap.Count);
            int cell = startCell;
            // Bubble down as long as either child is smaller.
            while (this.isLeftChildSmaller(cell) || this.isRightChildSmaller(cell))
            {
                int child = this.compareChild(cell);
                if (child == -1) // Left Child.
                {
                    // Swap values.
                    T parentValue    = _heap[cell];
                    T leftChildValue = _heap[2*cell];
                    _heap[cell]   = leftChildValue;
                    _heap[2*cell] = parentValue;
                    cell = 2*cell; // Move down to left child.
                }
                else if (child == 1) // Right Child.
                {
                    // Swap values.
                    T parentValue     = _heap[cell];
                    T rightChildValue = _heap[2*cell+1];
                    _heap[cell]     = rightChildValue;
                    _heap[2*cell+1] = parentValue;
                    cell = 2*cell+1; // Move down to right child.
                }
            }
        }
        /// <summary>Is the value of a parent greater than its child?</summary>
        private bool isParentBigger(int childCell)
        {
            // Requires(childCell >= 0);
            // Requires(childCell < _heap.Count);
            if (childCell == 1)
            {
                return false;  // Top of heap, no parent.
            }
            else
            {
                return _comparer(_heap[childCell/2], _heap[childCell]) > 0;
            }
        }
        /// <summary>
        /// Returns whether the left child cell is smaller than the parent cell.
        /// Returns false if a left child does not exist.
        /// </summary>
        private bool isLeftChildSmaller(int parentCell)
        {
            // Requires(parentCell >= 0);
            // Requires(parentCell < _heap.Count);
            if (2*parentCell >= _heap.Count)
            {
                return false; // Out of bounds.
            }
            else
            {
                return _comparer(_heap[2*parentCell], _heap[parentCell]) < 0;
            }
        }
        /// <summary>
        /// Returns whether the right child cell is smaller than the parent cell.
        /// Returns false if a right child does not exist.
        /// </summary>
        private bool isRightChildSmaller(int parentCell)
        {
            // Requires(parentCell >= 0);
            // Requires(parentCell < _heap.Count);
            if (2 * parentCell + 1 >= _heap.Count)
            {
                return false; // Out of bounds.
            }
            else
            {
                return _comparer(_heap[2*parentCell+1], _heap[parentCell]) < 0;
            }
        }
        /// <summary>
        /// Compares the children cells of a parent cell. -1 indicates the left child is the smaller of the two,
        /// 1 indicates the right child is the smaller of the two, 0 inidicates that neither child is smaller than the parent.
        /// </summary>
        private int compareChild(int parentCell)
        {
            // Requires(parentCell >= 0);
            // Requires(parentCell < _heap.Count);
            bool leftChildSmaller  = this.isLeftChildSmaller(parentCell);
            bool rightChildSmaller = this.isRightChildSmaller(parentCell);
            if (leftChildSmaller || rightChildSmaller)
            {
                if (leftChildSmaller && rightChildSmaller)
                {
                    // Figure out which of the two is smaller.
                    int leftChild  = 2 * parentCell;
                    int rightChild = 2 * parentCell + 1;
                    T leftValue  = this._heap[leftChild];
                    T rightValue = this._heap[rightChild];
                    // Compare the values of the children.
                    if (_comparer(leftValue, rightValue) <= 0)
                    {
                        return -1; // Left child is smaller.
                    }
                    else
                    {
                        return 1; // Right child is smaller.
                    }
                }
                else if (leftChildSmaller)
                {
                    return -1; // Left child is smaller.
                }
                else
                {
                    return 1; // Right child smaller.
                }
            }
            else
            {
                return 0; // Both children are bigger or don't exist.
            }
        }
        private readonly List<T>       _heap;
        private readonly Comparison<T> _comparer;
    }
