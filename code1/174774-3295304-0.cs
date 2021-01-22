List<IRole> newList = new List<IRole>();
for (int i = 1; i < list.Count; i++) // Start at 1, so we can do i - 1 on the first iteration
{
  if (list[i - 1].GetType() != list[i].GetType()) // they're not the same
  {
    newList.Add(list[i - 1]); // so add the first one too
  }
  newList.Add(list[i]); // always add second one
}
