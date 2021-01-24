C#
[Fact]
public async Task GetLdapEntries_ReturnsLdapEntries()
{
  var ldapEntries = new List<int> { 0, 1 };
  var creationTasks = new List<Task>();
  foreach (var led in ldapEntries)
  {
    var task = CreateLdapEntry(led);
    creationTasks.Add(task);
  }
  await Task.WhenAll(creationTasks);
}
public async Task<string> CreateLdapEntry(int ldapEntryDto)
{
  await Task.Delay(500);
  return "";
}
