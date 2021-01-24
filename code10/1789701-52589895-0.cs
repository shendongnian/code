	public class Node : PropertyChangedBase, INode
	{
		// #### Attributes
		private bool? _isSelected;
		private IList<INode> _nodes;
		private INode _parent;
		
		// #### Constructor
		public Node()
		{ }
		
		// #### Properties
		public bool? IsSelected
		{
			get { return _isSelected; }
			set
			{
				if (_SetField(ref _isSelected, value))
				{
					_OnIsSelectedChanged();
				}
			}
		}
		public IList<INode> Nodes
		{
			get { return _nodes; }
			set { _SetField(ref _nodes, value); }
		}
		public INode Parent
		{
			get { return _parent; }
			set { _SetField(ref _parent, value); }
		}
		
		// #### Events
		public event EventHandler IsSelectedChangedPropagationStarted;
		public event EventHandler IsSelectedChangedPropagationCompleted;
		
		// #### Instance Methods
		private void _OnIsSelectedChanged()
		{
			IsSelectedChangedPropagationStarted?.Invoke(this, EventArgs.Empty);
			
			if (IsSelected.HasValue)
			{
				if (IsSelected.Value)
				{
					RecursivelySetAllParents();
					
					if (Nodes != null && Nodes.Count > 0)
					{
						// Prevent running this method again by circumventing setting the property
						_SetField(ref _isSelected, null);
					}
				}
				else
				{
					if (Parent != null)
					{
						// Set IsSelected of the parent to null
					}
					
					RecursivelySetAllChildren();
				}
			}
			else if (Parent != null)
			{
				// Set IsSelected on all parenting nodes to:
				//  - true, if all of their immediate child packages have been selected
				//  - null, else
			}
			
			IsSelectedChangedPropagationCompleted?.Invoke(this, EventArgs.Empty);
		}
	}
