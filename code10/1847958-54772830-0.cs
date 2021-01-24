C#
[Fact]
public async Task GetLdapEntries_ReturnsLdapEntries()
{
  var ldapEntries = _fixture.CreateMany<LdapEntryDto>(2).ToList();
  var creationTasks = new List<Task>();
  foreach (var led in ldapEntries)
  {
    var task = _attributesServiceClient.CreateLdapEntry(led);
    creationTasks.Add(task);
  }
  await Task.WhenAll(creationTasks);
}
public async Task<LdapEntryDto> CreateLdapEntry(LdapEntryDto ldapEntryDto)
{
  await Task.Delay(500);
  return default(LdapEntryDto);
}
