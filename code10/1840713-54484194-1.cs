cs
List<ParentObject> CreateEntities(string json)
{
	var entities = JsonConvert.DeserializeObject<List<RootObject>>(json);
	List<ParentObject> parents = new List<ParentObject>();
	foreach (var entity in entities)
	{
		if (parents.Any(p => p.parentID == entity.parentID))
		{
			var parent = parents.Single(p => p.parentID == entity.parentID);
			if (parent.children.Any(c => c.childID == entity.childID))
			{
				var child = parent.children.Single(c => c.childID == entity.childID);
				if (entity.subChildID.HasValue)
				{
					child.subChildren.Add(new ParentObject.ChildObject.SubChildObject
					{
						subChildID = entity.subChildID.Value,
						subChildName = entity.subChildName
					});
				}
			}
			else
			{
				var newChild = (new ParentObject.ChildObject
				{
					childID = entity.childID,
					childName = entity.childName,
					subChildren = new List<ParentObject.ChildObject.SubChildObject>()
				});
				if (entity.subChildID.HasValue)
				{
					newChild.subChildren.Add(new ParentObject.ChildObject.SubChildObject
					{
						subChildID = entity.subChildID.Value,
						subChildName = entity.subChildName
					});
				}
				parent.children.Add(newChild);
			}
		}
		else
		{
			var newParent = new ParentObject
			{
				parentID = entity.parentID,
				parentName = entity.parentName,
				children = new List<ParentObject.ChildObject>
				{
				   	new ParentObject.ChildObject
					{
						childID = entity.childID,
						childName = entity.childName,
						subChildren = new List<ParentObject.ChildObject.SubChildObject>()
					}
				}
			};
			if (entity.subChildID.HasValue)
			{
				newParent.children.Single().subChildren.Add(new ParentObject.ChildObject.SubChildObject
				{
					subChildID = entity.subChildID.Value,
					subChildName = entity.subChildName
				});
			}
			parents.Add(newParent);
		}
	}
	return parents;
}
public class RootObject
{
	public int parentID { get; set; }
	public string parentName { get; set; }
	public int childID { get; set; }
	public string childName { get; set; }
	public int? subChildID { get; set; }
	public string subChildName { get; set; }
}
public class ParentObject
{
	public int parentID { get; set; }
	public string parentName { get; set; }
	public List<ChildObject> children { get; set; }
	public class ChildObject
	{
		public int childID { get; set; }
		public string childName { get; set; }
		public List<SubChildObject> subChildren { get; set; }
		public class SubChildObject
		{
			public int subChildID { get; set; }
			public string subChildName { get; set; }
		}
	}
}
Output:
[![enter image description here][1]][1]
Note:
This code handles multiple parents in one response, as although your question suggests that there is only one parent per response I wasn't completely sure.
  [1]: https://i.stack.imgur.com/TyWnE.png
